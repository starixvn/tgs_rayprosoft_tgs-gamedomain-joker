{{/*
Expand the name of the chart.
*/}}
{{- define "game-gamedomain-joker.name" -}}
{{- default .Chart.Name .Values.nameOverride | trunc 63 | trimSuffix "-" }}
{{- end }}

{{/*
Create a default fully qualified app name.
We truncate at 63 chars because some Kubernetes name fields are limited to this (by the DNS naming spec).
If release name contains chart name it will be used as a full name.
*/}}
{{- define "game-gamedomain-joker.fullname" -}}
{{- if .Values.fullnameOverride }}
{{- .Values.fullnameOverride | trunc 63 | trimSuffix "-" }}
{{- else }}
{{- $name := default .Chart.Name .Values.nameOverride }}
{{- if contains $name .Release.Name }}
{{- .Release.Name | trunc 63 | trimSuffix "-" }}
{{- else }}
{{- printf "%s-%s" .Release.Name $name | trunc 63 | trimSuffix "-" }}
{{- end }}
{{- end }}
{{- end }}

{{/*
Create chart name and version as used by the chart label.
*/}}
{{- define "game-gamedomain-joker.chart" -}}
{{- printf "%s-%s" .Chart.Name .Chart.Version | replace "+" "_" | trunc 63 | trimSuffix "-" }}
{{- end }}

{{/*
Common labels
*/}}
{{- define "game-gamedomain-joker.labels" -}}
helm.sh/chart: {{ include "game-gamedomain-joker.chart" . }}
{{ include "game-gamedomain-joker.selectorLabels" . }}
{{- if .Chart.AppVersion }}
app.kubernetes.io/version: {{ .Chart.AppVersion | quote }}
{{- end }}
app.kubernetes.io/managed-by: {{ .Release.Service }}
{{- end }}

{{/*
Selector labels
*/}}
{{- define "game-gamedomain-joker.selectorLabels" -}}
app.kubernetes.io/name: {{ include "game-gamedomain-joker.name" . }}
app.kubernetes.io/instance: {{ .Release.Name }}
app: {{ include "game-gamedomain-joker.name" . }}
tgs.kind: game
tgs.game.kind: gamedomain
tgs.gameprovider.kind: joker
{{- end }}

{{/*
Create the name of the service account to use
*/}}
{{- define "game-gamedomain-joker.serviceAccountName" -}}
{{- if .Values.serviceAccount.create }}
{{- default (include "game-gamedomain-joker.fullname" .) .Values.serviceAccount.name }}
{{- else }}
{{- default "default" .Values.serviceAccount.name }}
{{- end }}
{{- end }}
